    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Eventing.Reader;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace EventLogReading
    {
        class Program
        {
            static volatile bool myHasStoppedReading = false;
    
            static void ParseEventsParallel()
            {
                var sw = Stopwatch.StartNew();
                var query = new EventLogQuery("Application", PathType.LogName, "*");
    
                const int BatchSize = 100;
    
                ConcurrentQueue<EventRecord> events = new ConcurrentQueue<EventRecord>();
                var readerTask = Task.Factory.StartNew(() =>
                {
                    using (EventLogReader reader = new EventLogReader(query))
                    {
                        EventRecord ev;
                        bool bFirst = true;
                        int count = 0;
                        while ((ev = reader.ReadEvent()) != null)
                        {
                            if ( count % BatchSize == 0)
                            {
                                events.Enqueue(ev);
                            }
                            count++;
                        }
                    }
                    myHasStoppedReading = true;
                });
    
                ConcurrentQueue<KeyValuePair<string, EventRecord>> eventsWithStrings = new ConcurrentQueue<KeyValuePair<string, EventRecord>>();
    
                Action conversion = () =>
                {
                    EventRecord ev = null;
                    using (var reader = new EventLogReader(query))
                    {
                        while (!myHasStoppedReading || events.TryDequeue(out ev))
                        {
                            if (ev != null)
                            {
                                reader.Seek(ev.Bookmark);
                                for (int i = 0; i < BatchSize; i++)
                                {
                                    ev = reader.ReadEvent();
                                    if (ev == null)
                                    {
                                        break;
                                    }
                                    eventsWithStrings.Enqueue(new KeyValuePair<string, EventRecord>(ev.FormatDescription(), ev));
                                }
                            }
                        }
                    }
                };
    
                Parallel.Invoke(Enumerable.Repeat(conversion, 8).ToArray());
    
                sw.Stop();
                Console.WriteLine($"Got {eventsWithStrings.Count} events with strings in {sw.Elapsed.TotalMilliseconds:N3}ms");
            }
    
            static void ParseEvents()
            {
                var sw = Stopwatch.StartNew();
                List<KeyValuePair<string, EventRecord>> parsedEvents = new List<KeyValuePair<string, EventRecord>>();
                    
                using (EventLogReader reader = new EventLogReader(new EventLogQuery("Application", PathType.LogName, "*")))
                {
                    EventRecord ev;
                    while ((ev = reader.ReadEvent()) != null)
                    {
                        parsedEvents.Add(new KeyValuePair<string, EventRecord>(ev.FormatDescription(), ev));
                    }
                }
    
                sw.Stop();
                Console.WriteLine($"Got {parsedEvents.Count} events with strings in {sw.Elapsed.TotalMilliseconds:N3}ms");
            }
    
            static void Main(string[] args)
            {
                ParseEvents();
                ParseEventsParallel();
            }
        }
    }

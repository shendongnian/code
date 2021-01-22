    using System;
    
    namespace ObserverExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var subject = new Subject();
                var observer = new Observer();
                observer.Observe(subject);
                subject.SomeAction();
                Console.ReadLine();
            }
        }  
           
        public class Subject
        {
            public event EventHandler<TopicEventArgs> TopicHappening;
    
            public void SomeAction()
            {
                OnTopicHappening(new TopicEventArgs("Hello, observers!"));
            }
    
            protected virtual void OnTopicHappening(TopicEventArgs topicEventArgs)
            {
                EventHandler<TopicEventArgs> handler = TopicHappening;
    
                if (handler != null)
                    handler(this, topicEventArgs);
            }
        }
    
        public class TopicEventArgs : EventArgs
        {
            public TopicEventArgs(string message)
            {
                Message = message;
            }
    
            public string Message { get; private set; }
        }
        public class Observer
        {
            public void Observe(Subject subject)
            {
                subject.TopicHappening += subject_TopicHappening;
            }
    
            void subject_TopicHappening(object sender, TopicEventArgs e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

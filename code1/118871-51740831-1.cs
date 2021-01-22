      using System;
      using System.Collections.Generic;
      using System.Diagnostics;
      using System.Net.NetworkInformation;
      using System.Threading;
      namespace OnlineCheck
      {
          class Program
          {
              static bool isOnline = false;
              static void Main(string[] args)
              {
                  List<string> ipList = new List<string> {
                      "1.1.1.1", // Bad ip
                      "2.2.2.2",
                      "4.2.2.2",
                      "8.8.8.8",
                      "9.9.9.9",
                      "208.67.222.222",
                      "139.130.4.5"
                      };
                  int timeOut = 3 * 1000; // Seconds
                  List<Thread> threadList = new List<Thread>();
                  foreach (string ip in ipList)
                  {
                      Thread threadTest = new Thread(() => IsOnline(ip));
                      threadList.Add(threadTest);
                      threadTest.Start();
                  }
                  Stopwatch stopwatch = Stopwatch.StartNew();
                  while (!isOnline && stopwatch.ElapsedMilliseconds <= timeOut)
                  {
                       Thread.Sleep(10); // Cooldown the CPU
                  }
                  Console.WriteLine("Am I online: " + isOnline.ToYesNo());
                  Console.ReadKey();
              }
              static bool OnlineTest(string host, int timeout = 3000, int buffer = 32)
              {
                  bool result = false;
                  try
                  {
                      Ping pingX = new Ping();                
                      byte[] byteBuffer = new byte[buffer];                
                      PingOptions options = new PingOptions();
                      PingReply reply = pingX.Send(host, timeout, byteBuffer, options);
                      result = (reply.Status == IPStatus.Success);
                  }
                  catch (Exception ex)
                  {
                      
                  }
                  return result;
              }
              static void IsOnline(string host)
              {
                  isOnline =  OnlineTest(host) || isOnline;
              }
          }
          public static class BooleanExtensions
          {
              public static string ToYesNo(this bool value)
              {
                  return value ? "Yes" : "No";
              }
          }
      }

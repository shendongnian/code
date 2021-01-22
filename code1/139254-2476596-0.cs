    int fibsum = 1;
    Thread t = new Thread(o =>
                              {
                                  for (int i = 1; i < 20; i++)
                                  {
                                      fibsum += fibsum;
                                  }
                              });
    t.Start();
    t.Join(); // if you comment this line, the WriteLine will execute 
              // before the thread finishes and the result will be wrong
    Console.WriteLine(fibsum);

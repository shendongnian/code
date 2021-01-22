    public void Start()
            {
                var t1 = new Thread((message) => { Console.WriteLine(message); });
                //the parametirized threadstart accepts objects, it is not generic
                var t2 = new Thread(number => { var num = (int)number;
                Console.WriteLine(num++);
                });
                var t3 = new Thread((vals)=> work(vals));
                
                t1.Start();
                t2.Start();
                t3.Start(20);
            }
    
            public void work(params object[] vals)
            {
    
            }

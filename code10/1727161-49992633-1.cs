            DateTime nowDateTime = DateTime.Now;
            Dictionary<uint, Something> _somethingList = new Dictionary<uint, Something>();
            Console.WriteLine((DateTime.Now - nowDateTime).TotalSeconds.ToString() + " Creating List _somethingList");
            
                //slowly creating lsit so you can get memory usage incresing in profiler
            for (uint i = 1; i < 10; i++)
            {
                _somethingList.Add(i, new Something(i, "amit" + i.ToString()));
                System.Threading.Thread.Sleep(1000);
            }
            
            Console.WriteLine((DateTime.Now - nowDateTime).TotalSeconds.ToString() +  " Before creating test object");
            System.Threading.Thread.Sleep(5 * 1000);
            Another test = new Another(1, "Test", _somethingList[1]);
            Console.WriteLine((DateTime.Now - nowDateTime).TotalSeconds.ToString() + "  After creating test object");
            Console.WriteLine((DateTime.Now - nowDateTime).TotalSeconds.ToString() + "  Name before editing:" + test.Connection.Name);
            _somethingList[1].Name = "EditedName";
            Console.WriteLine((DateTime.Now - nowDateTime).TotalSeconds.ToString() + "  Name after editing:" + test.Connection.Name);

            Dictionary<uint, Something> _somethingList = new Dictionary<uint, Something>();
            for(uint i = 1; i < 100; i++)
                _somethingList.Add(i, new Something(i, "amit" + i.ToString()));
            
            Another test = new Another(1, "Test", _somethingList[1]);
            Console.WriteLine("Name before editing:" + test.Connection.Name);
            _somethingList[1].Name = "EditedName";
            Console.WriteLine("Name after editing:" + test.Connection.Name);

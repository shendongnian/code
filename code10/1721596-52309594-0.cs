    enter code here
                head = reader.ReadLine(); 
                while(!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(';'); 
    
                    Class rep;
                   
                    if (line[2] == "2.0")
                        rep = new Class2(line);
                     else if (line[2] == "2.1")
                        rep = new Class21(line);
                    else
                        rep = new Class51(line); 
                    listReproduktoru.Add(rep); 
                }
            }
            UpdateView();
    enter code here

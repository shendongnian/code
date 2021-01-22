        List<String> directories = new List<String>();
        void DirSearch(string sDir) 
        {
            try	
            {
                foreach (string d in Directory.GetDirectories(sDir)) 
                {
                    //foreach (string f in Directory.GetFiles(d, txtFile.Text)) 
                    //{
                    //    directories .Add(f);
                    //}
                    // use this to search for files recursivly.
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt) 
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private void CloseNotepad(){
            string proc = "NOTEPAD";
            
            Process[] processes = Process.GetProcesses();
            var pc = from p in processes
                     where p.ProcessName.ToUpper().Contains(proc)
                     select p;
            foreach (var item in pc)
            {
                item.CloseMainWindow();
            }
        }

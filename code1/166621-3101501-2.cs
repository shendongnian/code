    public class class1
    {
        // Not necessary, but will allow you to add custom EventArgs later
        public delegate void StatusChangedEventHandler(object sender, EventArgs e);
    
        public event StatusChangedEventHandler FileRead;
        public event StatusChangedEventHandler FileParsed;
        public event StatusChangedEventHandler FileSaved;
    
        public int DoOperation()    
        {    
            ReadTextFile();    
            ParsingData();    
            SaveTextFile();    
            return 0;    
        }    
        
        private int ReadTextFile()    
        {    
            //Read the text File
            FileRead(EventArgs.Empty);   
            return 0;
        }    
        
        private int ParsingData()    
        {    
            // Data manipulation
            FileParsed(EventArgs.Empty);
            return 0;       
        }    
        
        private int SaveTextFile()    
        {      
            // save the file
            FileSaved(EventArgs.Empty);
            return 0;    
        }
        protected virtual void OnFileRead(EventArgs e)
        {
            if(FileRead != null)
                FileRead(this, e);
        }
        protected virtual void OnFileParsed(EventArgs e)
        {
            if(FileParsed != null)
                FileParsed(this, e);
        }
        protected virtual void OnFileSaved(EventArgs e)
        {
            if(FileSaved != null)
                FileSaved(this, e);
        }
    }

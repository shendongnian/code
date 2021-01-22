        //content show in how many lines
        int TotalLine = 0;
        
        //start cursor line
        int cursorTop = 0;
        // use to set  character number show in one line
        int OneLineCharNum = 75;
        public void DumpInformation(string content)
        {
            OutPutInSameLine(content);
            SetBackSpace();
            
        }
        static void backspace(int n)
        {
            for (var i = 0; i < n; ++i)
                Console.Write("\b \b");
        }
        public  void SetBackSpace()
        {
          
            if (TotalLine == 0)
            {
                backspace(OneLineCharNum);
            }
            else
            {
                TotalLine--;
                while (TotalLine >= 0)
                {
                    backspace(OneLineCharNum);
                    TotalLine--;
                    if (TotalLine >= 0)
                    {
                        Console.SetCursorPosition(OneLineCharNum, cursorTop + TotalLine);
                    }
                }
            }
           
        }
        private void OutPutInSameLine(string content)
        {
            //Console.WriteLine(TotalNum);
            cursorTop = Console.CursorTop;
            
            TotalLine = content.Length / OneLineCharNum;
            if (content.Length % OneLineCharNum > 0)
            {
                TotalLine++;
            }
            if (TotalLine == 0)
            {
                Console.Write("{0}", content);
                
                return;
            }
            int i = 0;
            while (i < TotalLine)
            {
                int cNum = i * OneLineCharNum;
                if (i < TotalLine - 1)
                {
                    Console.WriteLine("{0}", content.Substring(cNum, OneLineCharNum));
                }
                else
                {
                    Console.Write("{0}", content.Substring(cNum, content.Length - cNum));
                }
                i++;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DumpOutPutInforInSameLine outPutInSameLine = new DumpOutPutInforInSameLine();
            outPutInSameLine.DumpInformation("");
            outPutInSameLine.DumpInformation("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            outPutInSameLine.DumpInformation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            outPutInSameLine.DumpInformation("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            //need serveral lines
            outPutInSameLine.DumpInformation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            outPutInSameLine.DumpInformation("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            outPutInSameLine.DumpInformation("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            outPutInSameLine.DumpInformation("bbbbbbbbbbbbbbbbbbbbbbbbbbb");
          
        }
    }

     struct WordInfo
     {
         public int position;
         public int fieldID;
     }
                
     Dictionary<string,List<WordInfo>> invertedIndex=new Dictionary<string,List<WordInfo>>();
                
           public void BuildIndex()
           {
                foreach (int  fieldID in GetDatabaseFieldIDS())
                {    
                    string textField=GetDatabaseTextFieldForID(fieldID);
                
                    string word;
                
                    int position=0;
                
                    while(GetNextWord(textField,out word,ref position)==true)
                    {
                         WordInfo wi=new WordInfo();
                
                         if (invertedIndex.TryGetValue(word,out wi)==false)
                         {
                             invertedIndex.Add(word,new List<WordInfo>());
                         }
                
                         wi.Position=position;
                         wi.fieldID=fieldID;
                         invertedIndex[word].Add(wi);
                 
                    }
                
                }
            }

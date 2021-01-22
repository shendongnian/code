    public List<string> GetDistinctTermList(string fieldName)
        {
            List<string> list = new List<string>();
            using (IndexReader reader = idxWriter.GetReader())
            {
                TermEnum te = reader.Terms(new Term(fieldName));
                
                if (te != null && te.Term != null && te.Term.Field == fieldName)
                {
                    list.Add(te.Term.Text);
                    while (te.Next())
                    {
                        if (te.Term.Field != fieldName)
                            break;
                        list.Add(te.Term.Text);
                    }
                }
            }
            return list;
        }

                for(int i=0; i < dt.Columns.Count; i++)
                    {
                        GridViewColumn gvc = new GridViewColumn();
                        gvc.Header = "Column"+i;
                        gvc.DisplayMemberBinding = new Binding("column"+i);
                        lvgvc.Columns.Add(gvc);
                    }

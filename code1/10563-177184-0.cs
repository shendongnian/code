                if (e.ColumnIndex == 1)
                {
                    string val = (string)e.Value;
                    e.Value = String.Format("   {0}", val);
                    e.FormattingApplied = true;
                }

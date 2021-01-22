    private void button1_Click(object sender, EventArgs e)
            {
                //Log(string.Format("Memory used before collection: {0}", GC.GetTotalMemory(false)));
                GC.Collect();
                //Log(string.Format("Memory used after collection: {0}", GC.GetTotalMemory(true)));
                listBox1.Items.Clear();
                if (string.IsNullOrEmpty(numericUpDown1.Text )) {
                    Log("Enter integer value");
                }else{
                    int val = (int) numericUpDown1.Value;
                    Log(TryAllocate(val));
                }
            }
    
            /// <summary>
            /// Memory Test method
            /// </summary>
            /// <param name="rowLen">in MB</param>
            private IEnumerable<string> TryAllocate(int rowLen) {
                var r = new List<string>();
                r.Add ( string.Format("Allocating using jagged array with overall size (MB) = {0}", ((long)rowLen*rowLen*Marshal.SizeOf(typeof(int))) >> 20) );
                try {
                    var ar = new int[rowLen][];
                    for (int i = 0; i < ar.Length; i++) {
                        try {
                            ar[i] = new int[rowLen];
                        }
                        catch (Exception e) {
                            r.Add ( string.Format("Unable to allocate memory on step {0}. Allocated {1} MB", i
                                , ((long)rowLen*i*Marshal.SizeOf(typeof(int))) >> 20 ));
                            break;
                        }
                    }
                    r.Add("Memory was successfully allocated");
                }
                catch (Exception e) {
                    r.Add(e.Message + e.StackTrace);
                }
                return r;
            }
    
            #region Logging
    
            private void Log(string s) {
                listBox1.Items.Add(s);
            }
    
            private void Log(IEnumerable<string> s)
            {
                if (s != null) {
                    foreach (var ss in s) {
                        listBox1.Items.Add ( ss );
                    }
                }
            }
    
            #endregion

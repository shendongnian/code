        /// <summary>
        /// Applies coloring to the result rows in the dataGrid
        /// </summary>
        private void ApplyColoring()
        {   
            if (dataGridView1.DataSource != null)
            {   
                // hardmap a color to a column
                IDictionary<Int32, Color> colorDictionary = new Dictionary<Int32, Color>();
                colorDictionary.Add(6, Color.FromArgb(194, 235, 211));
                colorDictionary.Add(7, Color.Salmon);
                colorDictionary.Add(8, Color.LightBlue);
                colorDictionary.Add(9, Color.LightYellow);
                colorDictionary.Add(10, Color.LightGreen);
                colorDictionary.Add(11, Color.LightCoral);
                colorDictionary.Add(12, Color.Blue);
                colorDictionary.Add(13, Color.Yellow);
                colorDictionary.Add(14, Color.Green);
                colorDictionary.Add(15, Color.White);
                IList<String> checkedValues = new List<String>();
                // first we loop through all the rows
                foreach (DataGridViewRow gridRow in dataGridView1.Rows)
                {
                    IDictionary<String, Int32> checkedVal = new Dictionary<String, Int32>();
                    // then we loop through all the data columns
                    int maxCol = dnsList.Count + 6;
                    for (int columnLoop = 6; columnLoop < maxCol; columnLoop++)
                    {
                        gridRow.Cells[columnLoop].Style.BackColor = Color.FromArgb(194, 235, 211);
                        string current = gridRow.Cells[columnLoop].Value.ToString();
                        for (int checkLoop = 6; checkLoop < maxCol; checkLoop++)
                        {
                            string check = gridRow.Cells[checkLoop].Value.ToString();
                            if (!current.Equals(check))
                            {
                                if (checkedVal.Keys.Contains(current))
                                {
                                    gridRow.Cells[columnLoop].Style.BackColor = colorDictionary[checkedVal[current]];
                                }
                                else
                                {
                                    gridRow.Cells[columnLoop].Style.BackColor = colorDictionary[columnLoop];
                                    checkedVal.Add(current, columnLoop);
                                }
                            }
                        }
                    }
                }
            }
        }

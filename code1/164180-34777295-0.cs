            foreach (var item in dynamicData)
            {
                var c = new TableHeaderCell()
                c.Text = item.Whatever;
                hr.Cells.Add(c);
            }
            //This is the important line
            hr.TableSection = TableRowSection.TableHeader;
            MyTable.Rows.Add(hr);

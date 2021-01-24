    if (emord.Text == "Ascending")
            {
                if (emsort.Text == "ID")
                {
                    var empName = el.Select(i => new { i.ID, i.FullName }).OrderBy(x => x.ID);
                    var empNamenAmp = el.Select(i => new { i.ID, i.FullName, i.Salary, i.Currency, i.Per }).OrderBy(x => x.ID);
                    var empNamenAmpnwh = el.Select(i => new { i.ID, i.FullName, i.Salary, i.Currency, i.Per, i.Hours }).OrderBy(x => x.ID);
                    var empNamenwh = el.Select(i => new { i.ID, i.FullName, i.Hours }).OrderBy(x => x.ID);
                    var empNamenbd = el.Select(i => new { i.ID, i.FullName, i.Date }).OrderBy(x => x.ID);
                    var empNamenad = el.Select(i => new { i.ID, i.FullName, i.Location }).OrderBy(x => x.ID);
                    var empNamenpn = el.Select(i => new { i.ID, i.FullName, i.PhoneNb }).OrderBy(x => x.ID);
                    var empNamena = el.Select(i => new { i.ID, i.FullName, i.Age }).OrderBy(x => x.ID);
                    if (empfilcomb.Text == "Name")
                    {
                        dispfil.Clear();
                        foreach (var x in empName)
                            dispfil.Text += x.ID + ", " + x.FullName + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Amount paid")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenAmp)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Salary + " " + x.Currency + " " + x.Per + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Work Hours")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenwh)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Hours + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name,Amount paid and Work Hours")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenAmpnwh)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Salary + " " + x.Currency + " " + x.Per + ", " + x.Hours + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Birthday")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenbd)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Date + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Address")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenad)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Location + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Phone Number")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenpn)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.PhoneNb + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Age")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamena)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Age + Environment.NewLine;
                    }
                }
                else if (emsort.Text == "Name")
                {
                    var empName = el.Select(i => new { i.ID, i.FullName }).OrderBy(x => x.FullName);
                    var empNamenAmp = el.Select(i => new { i.ID, i.FullName, i.Salary, i.Currency, i.Per }).OrderBy(x => x.FullName);
                    var empNamenAmpnwh = el.Select(i => new { i.ID, i.FullName, i.Salary, i.Currency, i.Per, i.Hours }).OrderBy(x => x.FullName);
                    var empNamenwh = el.Select(i => new { i.ID, i.FullName, i.Hours }).OrderBy(x => x.FullName);
                    var empNamenbd = el.Select(i => new { i.ID, i.FullName, i.Date }).OrderBy(x => x.FullName);
                    var empNamenad = el.Select(i => new { i.ID, i.FullName, i.Location }).OrderBy(x => x.FullName);
                    var empNamenpn = el.Select(i => new { i.ID, i.FullName, i.PhoneNb }).OrderBy(x => x.FullName);
                    var empNamena = el.Select(i => new { i.ID, i.FullName, i.Age }).OrderBy(x => x.FullName);
                    if (empfilcomb.Text == "Name")
                    {
                        dispfil.Clear();
                        foreach (var x in empName)
                            dispfil.Text += x.ID + ", " + x.FullName + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Amount paid")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenAmp)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Salary + " " + x.Currency + " " + x.Per + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Work Hours")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenwh)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Hours + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name,Amount paid and Work Hours")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenAmpnwh)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Salary + " " + x.Currency + " " + x.Per + ", " + x.Hours + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Birthday")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenbd)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Date + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Address")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenad)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Location + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Phone Number")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamenpn)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.PhoneNb + Environment.NewLine;
                    }
                    else if (empfilcomb.Text == "Name and Age")
                    {
                        dispfil.Clear();
                        foreach (var x in empNamena)
                            dispfil.Text += x.ID + ", " + x.FullName + ", " + x.Age + Environment.NewLine;
                    }
                }

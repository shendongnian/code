                    string name = inputFile.ReadLine();
                    //Calculates average for systolic
                    double total = 0;
                    for (int count = 0; count < systolic.Length; count++)
                    {
                        total += systolic[count];
                    }
                    double average_sys = total / 5;
                    int doctor = int.Parse(inputFile.ReadLine());
                    string DocN = doctors[doctor];
                    listBox1.Items.Add(name + "\t" + average_sys + "\t" + DocN);

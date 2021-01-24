    int start = inLine.IndexOf("'");
                if (start >= 0)
                {
                    inLine = inLine.Substring(start);
                    int end = inLine.IndexOf(" ");
                    string lastname = inLine.Substring(0, end);
                    int endTwo = inLine.IndexOf(' ', end + 1);
                    string firstname = inLine.Substring(end, endTwo - end);
                    int endThree = inLine.IndexOf(' ', endTwo + 1);
                    string middleinitial = inLine.Substring(endTwo, endThree - endTwo);
                    endThree += 2; // to escape ')' after middle initial
                    int endFour = inLine.IndexOf(' ', endThree + 1);
                    string phone = inLine.Substring(endThree, endFour - endThree);
                    int endFive = inLine.IndexOf(' ', endFour + 1);
                    string email = inLine.Substring(endFour, endFive - endFour);
                    int endSix = inLine.IndexOf(' ', endFive + 1);
                    string gpa = inLine.Substring(endFive, endSix - endFive);
                    Console.WriteLine("Last Name - " + lastname);
                    Console.WriteLine("First Name - " + firstname);
                    Console.WriteLine("Middle Initial - " + middleinitial);
                    Console.WriteLine("Phone - " + phone);
                    Console.WriteLine("Email - " + email);
                    Console.WriteLine("GPA - " + gpa);
                }
    

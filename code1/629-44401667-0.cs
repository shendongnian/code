     namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text.RegularExpressions;
        class Program
        {
           static void Main(string[] args)
            {
                bool repeat = true;
                while (repeat)
                {
                    string inputMonetaryValueInNumberic = string.Empty;
                    string centPart = string.Empty;
                    string dollarPart = string.Empty;
                    Console.Write("\nEnter the monetary value : ");
                    inputMonetaryValueInNumberic = Console.ReadLine();
                    inputMonetaryValueInNumberic = inputMonetaryValueInNumberic.TrimStart('0');
    
                    if (ValidateInput(inputMonetaryValueInNumberic))
                    {
    
                        if (inputMonetaryValueInNumberic.Contains('.'))
                        {
                            centPart = ProcessCents(inputMonetaryValueInNumberic.Substring(inputMonetaryValueInNumberic.IndexOf(".") + 1));
                            dollarPart = ProcessDollar(inputMonetaryValueInNumberic.Substring(0, inputMonetaryValueInNumberic.IndexOf(".")));
                        }
                        else
                        {
                            dollarPart = ProcessDollar(inputMonetaryValueInNumberic);
                        }
                        centPart = string.IsNullOrWhiteSpace(centPart) ? string.Empty : " and " + centPart;
                        Console.WriteLine(string.Format("\n\n{0}{1}", dollarPart, centPart));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input..");
                    }
    
                    Console.WriteLine("\n\nPress any key to continue or Escape of close : ");
                    var loop = Console.ReadKey();
                    repeat = !loop.Key.ToString().Contains("Escape");
                    Console.Clear();
                }
    
            }
    
            private static string ProcessCents(string cents)
            {
                string english = string.Empty;
                string dig3 = Process3Digit(cents);
                if (!string.IsNullOrWhiteSpace(dig3))
                {
                    dig3 = string.Format("{0} {1}", dig3, GetSections(0));
                }
                english = dig3 + english;
                return english;
            }
            private static string ProcessDollar(string dollar)
            {
                string english = string.Empty;
                foreach (var item in Get3DigitList(dollar))
                {
                    string dig3 = Process3Digit(item.Value);
                    if (!string.IsNullOrWhiteSpace(dig3))
                    {
                        dig3 = string.Format("{0} {1}", dig3, GetSections(item.Key));
                    }
                    english = dig3 + english;
                }
                return english;
            }
            private static string Process3Digit(string digit3)
            {
                string result = string.Empty;
                if (Convert.ToInt32(digit3) != 0)
                {
                    int place = 0;
                    Stack<string> monetaryValue = new Stack<string>();
                    for (int i = digit3.Length - 1; i >= 0; i--)
                    {
                        place += 1;
                        string stringValue = string.Empty;
                        switch (place)
                        {
                            case 1:
                                stringValue = GetOnes(digit3[i].ToString());
                                break;
                            case 2:
                                int tens = Convert.ToInt32(digit3[i]);
                                if (tens == 1)
                                {
                                    if (monetaryValue.Count > 0)
                                    {
                                        monetaryValue.Pop();
                                    }
                                    stringValue = GetTens((digit3[i].ToString() + digit3[i + 1].ToString()));
                                }
                                else
                                {
                                    stringValue = GetTens(digit3[i].ToString());
                                }
                                break;
                            case 3:
                                stringValue = GetOnes(digit3[i].ToString());
                                if (!string.IsNullOrWhiteSpace(stringValue))
                                {
                                    string postFixWith = " Hundred";
                                    if (monetaryValue.Count > 0)
                                    {
                                        postFixWith = postFixWith + " And";
                                    }
                                    stringValue += postFixWith;
                                }
                                break;
                        }
                        if (!string.IsNullOrWhiteSpace(stringValue))
                            monetaryValue.Push(stringValue);
                    }
                    while (monetaryValue.Count > 0)
                    {
                        result += " " + monetaryValue.Pop().ToString().Trim();
                    }
                }
                return result;
            }
            private static Dictionary<int, string> Get3DigitList(string monetaryValueInNumberic)
            {
                Dictionary<int, string> hundredsStack = new Dictionary<int, string>();
                int counter = 0;
                while (monetaryValueInNumberic.Length >= 3)
                {
                    string digit3 = monetaryValueInNumberic.Substring(monetaryValueInNumberic.Length - 3, 3);
                    monetaryValueInNumberic = monetaryValueInNumberic.Substring(0, monetaryValueInNumberic.Length - 3);
                    hundredsStack.Add(++counter, digit3);
                }
                if (monetaryValueInNumberic.Length != 0)
                    hundredsStack.Add(++counter, monetaryValueInNumberic);
                return hundredsStack;
            }
            private static string GetTens(string tensPlaceValue)
            {
                string englishEquvalent = string.Empty;
                int value = Convert.ToInt32(tensPlaceValue);
                Dictionary<int, string> tens = new Dictionary<int, string>();
                tens.Add(2, "Twenty");
                tens.Add(3, "Thirty");
                tens.Add(4, "Forty");
                tens.Add(5, "Fifty");
                tens.Add(6, "Sixty");
                tens.Add(7, "Seventy");
                tens.Add(8, "Eighty");
                tens.Add(9, "Ninty");
                tens.Add(10, "Ten");
                tens.Add(11, "Eleven");
                tens.Add(12, "Twelve");
                tens.Add(13, "Thrteen");
                tens.Add(14, "Fourteen");
                tens.Add(15, "Fifteen");
                tens.Add(16, "Sixteen");
                tens.Add(17, "Seventeen");
                tens.Add(18, "Eighteen");
                tens.Add(19, "Ninteen");
                if (tens.ContainsKey(value))
                {
                    englishEquvalent = tens[value];
                }
    
                return englishEquvalent;
    
            }
            private static string GetOnes(string onesPlaceValue)
            {
                int value = Convert.ToInt32(onesPlaceValue);
                string englishEquvalent = string.Empty;
                Dictionary<int, string> ones = new Dictionary<int, string>();
                ones.Add(1, " One");
                ones.Add(2, " Two");
                ones.Add(3, " Three");
                ones.Add(4, " Four");
                ones.Add(5, " Five");
                ones.Add(6, " Six");
                ones.Add(7, " Seven");
                ones.Add(8, " Eight");
                ones.Add(9, " Nine");
    
                if (ones.ContainsKey(value))
                {
                    englishEquvalent = ones[value];
                }
    
                return englishEquvalent;
            }
            private static string GetSections(int section)
            {
                string sectionName = string.Empty;
                switch (section)
                {
                    case 0:
                        sectionName = "Cents";
                        break;
                    case 1:
                        sectionName = "Dollars";
                        break;
                    case 2:
                        sectionName = "Thousand";
                        break;
                    case 3:
                        sectionName = "Million";
                        break;
                    case 4:
                        sectionName = "Billion";
                        break;
                    case 5:
                        sectionName = "Trillion";
                        break;
                    case 6:
                        sectionName = "Zillion";
                        break;
                }
                return sectionName;
            }
            private static bool ValidateInput(string input)
            {
                return Regex.IsMatch(input, "[0-9]{1,18}(\\.[0-9]{1,2})?"))
            }
        }
    }

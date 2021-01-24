    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Where is the data file for batting averages located? ");
            string doc = Console.ReadLine();
            int[] avg = new int[9];
            int val1=0, val2=0, val3=0, val4=0, val5=0, val6=0, val7=0, val8=0, val9=0;
            int cnt1=0, cnt2=0, cnt3=0, cnt4=0, cnt5=0, cnt6=0, cnt7=0, cnt8=0, cnt9=0;
            try
            {
                StreamReader reader = new StreamReader(doc);
                var lines = File.ReadAllLines(doc);
                int[] index = Array.ConvertAll(lines, int.Parse);
                //Console.WriteLine(lines); //displays contents of text file
                reader.Close();
                for (int i = 0;  i < index.Length; i += 2)
                {
                    switch (index[i])
                    {
                        case 1:
                            cnt1++;
                            val1 = val1 + index[i + 1];
                            break;
                        case 2:
                            cnt2++;
                            val2 = val2 + index[i + 1];
                            break;
                        case 3:
                            cnt3++;
                            val3 = val3 + index[i + 1];
                            break;
                        case 4:
                            cnt4++;
                            val4 = val4 + index[i + 1];
                            break;
                        case 5:
                            cnt5++;
                            val5 = val5 + index[i + 1];
                            break;
                        case 6:
                            cnt6++;
                            val6 = val6 + index[i + 1];
                            break;
                        case 7:
                            cnt7++;
                            val7 = val7 + index[i + 1];
                            break;
                        case 8:
                            cnt8++;
                            val8 = val8 + index[i + 1];
                            break;
                        case 9:
                            cnt9++;
                            val9 = val9 + index[i + 1];
                            break;
                        default:
                            break;
                    }
                }
                int total = cnt1 + cnt2 + cnt3 + cnt4 + cnt5 + cnt6 + cnt7 + cnt8 + cnt9;
                decimal avg1 = Convert.ToDecimal(val1) / Convert.ToDecimal(cnt1);
                decimal avg2 = Convert.ToDecimal(val2) / Convert.ToDecimal(cnt2);
                decimal avg3 = Convert.ToDecimal(val3) / Convert.ToDecimal(cnt3);
                decimal avg4 = Convert.ToDecimal(val4) / Convert.ToDecimal(cnt4);
                decimal avg5 = Convert.ToDecimal(val5) / Convert.ToDecimal(cnt5);
                decimal avg6 = Convert.ToDecimal(val6) / Convert.ToDecimal(cnt6);
                decimal avg7 = Convert.ToDecimal(val7) / Convert.ToDecimal(cnt7);
                decimal avg8 = Convert.ToDecimal(val8) / Convert.ToDecimal(cnt8);
                decimal avg9 = Convert.ToDecimal(val9) / Convert.ToDecimal(cnt9);
                Console.WriteLine("{0} pairs of data read.", total);
                Console.WriteLine("The batting average for:");
                Console.WriteLine("   position 1 is {0}", Math.Round(avg1, 4));
                Console.WriteLine("   position 2 is {0}", Math.Round(avg2, 4));
                Console.WriteLine("   position 3 is {0}", Math.Round(avg3, 4));
                Console.WriteLine("   position 4 is {0}", Math.Round(avg4, 4));
                Console.WriteLine("   position 5 is {0}", Math.Round(avg5, 4));
                Console.WriteLine("   position 6 is {0}", Math.Round(avg6, 4));
                Console.WriteLine("   position 7 is {0}", Math.Round(avg7, 4));
                Console.WriteLine("   position 8 is {0}", Math.Round(avg8, 4));
                Console.WriteLine("   position 9 is {0}", Math.Round(avg9, 4));
            }
            catch (System.IO.FileNotFoundException) //file not present
            {
                Console.WriteLine("The file {0} was not found.", doc);
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Incomplete data pairs. Please re-check your data entries and retry.");
            }
            catch (System.FormatException) //bad data
            {
                Console.WriteLine("Invalid file.");
            }
            catch (System.ArgumentException) //null entry
            {
                Console.WriteLine("Make sure you enter a valid file name.");
            }
            catch (System.Exception exc) //any other exceptions
            {
                Console.WriteLine(exc.Message);
            }
        }
      }
    }

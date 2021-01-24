        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace ConsoleApp1
        {
            internal class Program
            {
                public static byte[] _globalDataStore { get; set; }
                private static void Main(string[] args)
                {
                    DoStuff();
                    ShowDone();
                }
        
                private static void ShowDone()
                {
                    Console.WriteLine("done...");
                    Console.ReadKey();
                }
        
                private static void DoStuff()
                {
                    var tempData = GetData();
                    StoreData(ref tempData);
                    tempData = null; //free some ram
                    var dataIdentifier = (byte)'\n';
                    GetAndPromptDataPositions(_globalDataStore, dataIdentifier);
                }
        
                private static void GetAndPromptDataPositions<T>(T[] data, T dataIdentifier)
                {
                    var dataPositionList = GetDataPositions<T>(data, dataIdentifier);
                    PromptDataPostions(dataPositionList);
                }
        
                private static void PromptDataPostions(IEnumerable<long> positionList)
                {
                    foreach (var position in positionList)
                    {
                        Console.WriteLine($"Position '{position}'");
                    }
                }
                private static string GetData()
                {
                    return "aasdlj\naksdlkajsdlkasldj\nasld\njkalskdjasldjlasd";
                }
        
                private static void StoreData(ref string tempData)
                {
                    _globalDataStore = Encoding.ASCII.GetBytes(tempData);
                }
        
                private static List<long> GetDataPositions<T>(T[] data, T dataToFind)
                {
                    lock (data) //prevent data from being changed while processing, important when have other threaded could write data 
                    {
                        var postitonList = new List<long>();
                        Parallel.For(0, data.LongLength, (position) =>
                        {
                            if (data[position].Equals(dataToFind))
                            {
                                lock (postitonList) //lock list because of multithreaded access to prevent data corruption
                                {
                                    postitonList.Add(position);
                                }
                            }
                        });
                        return postitonList;
                    }
                }
            }
        }

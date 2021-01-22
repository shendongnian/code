        using System.Collections.ObjectModel;
    
        namespace IntIntKeyedCollection
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Int32Int32DateO iid1 = new Int32Int32DateO(0, 1, new DateTime(2007, 6, 1, 8, 30, 52));
                    Int32Int32DateO iid2 = new Int32Int32DateO(0, 1, new DateTime(2007, 6, 1, 8, 30, 52));
                    if (iid1 == iid2) Console.WriteLine("same");
                    if (iid1.Equals(iid2)) Console.WriteLine("equals");
                    // that are equal but not the same I don't override = so I have both features
                    
                    Int32Int32DateCollection int32Int32DateCollection = new Int32Int32DateCollection();
                    // dont't have to repeat the key like Dictionary
                    int32Int32DateCollection.Add(new Int32Int32DateO(0, 0, new DateTime(2008, 5, 1, 8, 30, 52)));
                    int32Int32DateCollection.Add(new Int32Int32DateO(0, 1, new DateTime(2008, 6, 1, 8, 30, 52)));
                    int32Int32DateCollection.Add(iid1);
                    //this would thow a duplicate key error
                    //int32Int32DateCollection.Add(iid2);
                    //this would thow a duplicate key error
                    //int32Int32DateCollection.Add(new Int32Int32DateO(0, 1, new DateTime(2008, 6, 1, 8, 30, 52)));
                    Console.WriteLine("count");
                    Console.WriteLine(int32Int32DateCollection.Count.ToString());
                    // reference by ordinal postion (note the is not the long key)
                    Console.WriteLine("oridinal");
                    Console.WriteLine(int32Int32DateCollection[0].GetHashCode().ToString());
                    // reference by index
                    Console.WriteLine("index");
                    Console.WriteLine(int32Int32DateCollection[0, 1, new DateTime(2008, 6, 1, 8, 30, 52)].GetHashCode().ToString());
                    Console.WriteLine("foreach");
                    foreach (Int32Int32DateO iio in int32Int32DateCollection)
                    {
                        Console.WriteLine(string.Format("HashCode {0} Int1 {1} Int2 {2} DateTime {3}", iio.GetHashCode(), iio.Int1, iio.Int2, iio.Date1));
                    }
                    Console.WriteLine("sorted by date");
                    foreach (Int32Int32DateO iio in int32Int32DateCollection.OrderBy(x => x.Date1).ThenBy(x => x.Int1).ThenBy(x => x.Int2))
                    {
                        Console.WriteLine(string.Format("HashCode {0} Int1 {1} Int2 {2} DateTime {3}", iio.GetHashCode(), iio.Int1, iio.Int2, iio.Date1));
                    }
                    Console.ReadLine();
                }
                public class Int32Int32DateCollection : KeyedCollection<Int32Int32DateS, Int32Int32DateO>
                {
                    // This parameterless constructor calls the base class constructor 
                    // that specifies a dictionary threshold of 0, so that the internal 
                    // dictionary is created as soon as an item is added to the  
                    // collection. 
                    // 
                    public Int32Int32DateCollection() : base(null, 0) { }
        
                    // This is the only method that absolutely must be overridden, 
                    // because without it the KeyedCollection cannot extract the 
                    // keys from the items.  
                    // 
                    protected override Int32Int32DateS GetKeyForItem(Int32Int32DateO item)
                    {
                        // In this example, the key is the part number. 
                        return item.Int32Int32Date;
                    }
        
                    //  indexer 
                    public Int32Int32DateO this[Int32 Int1, Int32 Int2, DateTime Date1]
                    {
                        get { return this[new Int32Int32DateS(Int1, Int2, Date1)]; }
                    }
                }
        
                public struct Int32Int32DateS
                {   // required as KeyCollection Key must be a single item
                    // but you don't really need to interact with Int32Int32DateS directly
                    public readonly Int32 Int1, Int2;
                    public readonly DateTime Date1;
                    public Int32Int32DateS(Int32 int1, Int32 int2, DateTime date1)
                    { this.Int1 = int1; this.Int2 = int2; this.Date1 = date1; }
                }
                public class Int32Int32DateO : Object
                {
                    // implement other properties
                    public Int32Int32DateS Int32Int32Date { get; private set; }
                    public Int32 Int1 { get { return Int32Int32Date.Int1; } }
                    public Int32 Int2 { get { return Int32Int32Date.Int2; } }
                    public DateTime Date1 { get { return Int32Int32Date.Date1; } }
                    
                    public override bool Equals(Object obj)
                    {
                        //Check for null and compare run-time types.
                        if (obj == null || !(obj is Int32Int32DateO)) return false;
                        Int32Int32DateO item = (Int32Int32DateO)obj;
                        return (this.Int32Int32Date.Int1 == item.Int32Int32Date.Int1 &&
                                this.Int32Int32Date.Int2 == item.Int32Int32Date.Int2 &&
                                this.Int32Int32Date.Date1 == item.Int32Int32Date.Date1);
                    }
                    public override int GetHashCode()
                    {
                        return (((Int64)Int32Int32Date.Int1 << 32) + Int32Int32Date.Int2).GetHashCode() ^ Int32Int32Date.GetHashCode();
                    }
                    public Int32Int32DateO(Int32 Int1, Int32 Int2, DateTime Date1)
                    {
                        Int32Int32DateS int32Int32Date = new Int32Int32DateS(Int1, Int2, Date1);
                        this.Int32Int32Date = int32Int32Date;
                    }
                }
            }
        }

    public class Listem
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public byte Week { get; set; }
        public char Process { get; set; }
        public string PerName { get; set; }
        public float Pips { get; set; }
        public Listem(int id, string perName, char longShort, byte hafta, float pips)
        {
            ID = id;
            PerName = perName;
            Process = longShort;
            Week = hafta;
            Pips = pips;
        }
        public override string ToString()
        {
            return $"ID : {ID}\tPerName : {PerName} Tarih : {Date:yyyy-MM-dd}" + 
                $"\tİşlem Yönü : {Process}\tHafta : {Week}\tPips :  {Pips}";
        }
    }

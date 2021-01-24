    public class data
    {
        public int id { get; set; }
        public string Variable { get; set; }
        public string Value { get; set; }
        public decimal Coef { get; set; }
    }
    var listy = new List<data>() {
        new data() { id=1000, Variable="Gender", Value="Male", Coef=0m },
        new data() { id=1001, Variable="Gender", Value="Female", Coef=-0.205m },
        new data() { id=1009, Variable="College Code", Value="AT", Coef=-1.732m },
        new data() { id=1010, Variable="College Code", Value="BU", Coef=-1.806m },
        new data() { id=1011, Variable="College Code", Value="EH", Coef=-1.728m },
        new data() { id=1012, Variable="College Code", Value="EN", Coef=-2.003m },
        new data() { id=1013, Variable="College Code", Value="LF", Coef=-1.779m },
        new data() { id=1014, Variable="College Code", Value="pp", Coef=-2.042m },
        new data() { id=1015, Variable="College Code", Value="SC", Coef=-2.070m },
        new data() { id=1016, Variable="College Code", Value="UC", Coef=-1.845m },
        new data() { id=1017, Variable="AGI", Value="AGI N/A", Coef=0.236m },
        new data() { id=1018, Variable="AGI", Value="0", Coef=-0.684m },
    };

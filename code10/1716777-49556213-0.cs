    public class person{
     public person(){ country=new country(); }string name { get; set; }
    public country country { get; set; }
    int pk_country { get; set; }
    decimal basicSalary { get; set; }
    decimal actualSalary { get { if (country.lang == lang.en) return (decimal)15.99 * basicSalary; else return basicSalary + (decimal)14.99; } }}
 

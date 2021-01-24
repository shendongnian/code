    public Double? StringToDouble(String input){
        if(Double.TryParse(input, out Double d)) {
            Console.WriteLine("The double value is {0}", d);
            return d;
        }
        else{
           Console.WriteLine("The input string was not in correct format");
       }
       return null;
    }

    public Static void main(){
        string text = "Test Text";
        Console.Writeline(RevestString(text))
    }
    public Static string RevestString(string text){
        char[] textToChar = text.ToCharArray();
        string result= string.Empty;
        int length = textToChar .Length;
        for (int i = length; i > 0; --i)
        result += textToChar[i - 1];
        return result;
    }

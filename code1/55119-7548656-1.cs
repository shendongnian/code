    private bool ValidChar(string _char)
    {
       string Lista = @" ! "" # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z ";
       return Lista.IndexOf(_char.ToUpper()) != -1;
       //System.Text.RegularExpressions.Regex RegVal = new System.Text.RegularExpressions.Regex(@"(?<LETRAS>[A-Z]+)+(?<NUMERO>[0-9]+)+(?<CAR>[!|""|#|$|%|&|'|(|)|*|+|,|\-|.|/|:|;|<|=|>|?|@]+)+");
       //return RegVal.IsMatch(_char);
    }
    private void textBoxDescripcion_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!ValidChar(e.Text))
             e.Handled = true;
    }

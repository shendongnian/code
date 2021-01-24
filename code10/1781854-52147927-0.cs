     string str = "לא קיימת תוכנה לשליחת מיילים במכשיר, אנא פנה אלינו ישירות ל moshecohen@gmail.com";
     string pattern = @"[\p{IsHebrew}]+";
     var hebrewMatchCollection = Regex.Matches(str, pattern);
     string hebrewPart = string.Join(" ", hebrewMatchCollection.Cast<Match>().Select(m => m.Value));  //combine regex collection
     var englishPart = Regex.Split(str, pattern).Last(); 

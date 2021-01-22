     char[] splits = new char[1];
     splits[0] = ' ';
     string[] split = addressLine.split(splits);
     int splitLoc = -1, i;
     for (i =1; i < split.Length; i++){//start at 1 to avoid the first '2e' streets
         int theFirstDigit = -1;
         try{
            theFirstDigit = int.Parse(split[i].Substring(0,1));
         }catch {
            //ignore; parse fails with an exception
         }
         if (theFirstDigit != -1){
             splitLoc = i;
             break;
         }
     }
     if (splitLoc < 0) return; //busted
     string field1, field2;
     for (i = 0; i < splitLoc; i++){
         field1+= split[i] + " ";
     }
     for (i = splitLoc; i < split.Length; i++){
         field2+= split[i] + " ";
     }

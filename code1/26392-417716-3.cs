    inside_space = false // this flag will tell us if we are inside 
                         // a white space.
    for each character in string do
        if( character is white space ) then 
             inside_space = true // you're in an space...
                                 // raise your flag.
         else  if( character is not white space AND 
                   inside_space == true ) then 
               // this means you're not longer in a space 
               // ( thus the beginning of a word exactly what you want ) 
              character = character.toUper()  // convert the current 
                                              // char to upper case
              inside_space = false;           // turn the flag to false
                                              // so the next won't be uc'ed
         end
         
         // Here you just add your letter to the string 
         // either white space, upercased letter or any other.
         result =  result + character 
     end // for
        

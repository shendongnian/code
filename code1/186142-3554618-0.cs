    class test {
      List<string> someElement;
    }
    
    class xmlEnum 
    {
     static test createObject(string inputXml) 
     {
         test t = new test();
         // load input xml in XmlDocument class
         // and start iterating thorugh all the elements
         swithc(elementName)
         {
            case rep1:
                t.someElement.add(element.innerText);
                break;
             // some more cases will go here
    
         }
       // finally return the object;
      return t;
     }
    }

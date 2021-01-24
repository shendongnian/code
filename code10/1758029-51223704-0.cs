    public List<string> getText(){
    List<string> list = new List<string>();
    IList<IWebElement> radio_option = Driver.FindElements(By.Name("loan_is_a"))
    foreach (IWebElement element in radio_option ){  
            list.ADD(element.GetText());
            return list;
        }
        }

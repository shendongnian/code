    public class TestBase
    {
        public T NavigateandReturntheObject<T>() where T : class,new()
        {
            //do navigate to page stuff and return the page object
    
            //previously it was - return new T();
    
            //Now i want to do something like this
            return PageObjectBase<T>.PageObject;
        }
    }
    

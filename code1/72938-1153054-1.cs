    using System;  
    using System.Collections;  
    using System.Linq;  
    using System.Xml.Linq;  
      
    /// <summary>Represent an Exception as XML data.</summary>  
    public class ExceptionXElement : XElement  
    {  
        /// <summary>Create an instance of ExceptionXElement.</summary>  
        /// <param name="exception">The Exception to serialize.</param>  
        public ExceptionXElement(Exception exception)  
            : this(exception, false)  
        { }  
      
        /// <summary>Create an instance of ExceptionXElement.</summary>  
        /// <param name="exception">The Exception to serialize.</param>  
        /// <param name="omitStackTrace">  
        /// Whether or not to serialize the Exception.StackTrace member  
        /// if it's not null.  
        /// </param>  
        public ExceptionXElement(Exception exception, bool omitStackTrace)  
            : base(new Func<XElement>(() =>  
            {  
                // Validate arguments  
      
                if (exception == null)  
                {  
                    throw new ArgumentNullException("exception");  
                }  
      
                // The root element is the Exception's type  
      
                XElement root = new XElement  
                    (exception.GetType().ToString());  
      
                if (exception.Message != null)  
                {  
                    root.Add(new XElement("Message", exception.Message));  
                }  
      
                // StackTrace can be null, e.g.:  
                // new ExceptionAsXml(new Exception())  
      
                if (!omitStackTrace && exception.StackTrace != null)  
                {  
                    root.Add  
                    (  
                        new XElement("StackTrace",  
                            from frame in exception.StackTrace.Split('\n')  
                            let prettierFrame = frame.Substring(6).Trim()  
                            select new XElement("Frame", prettierFrame))  
                    );  
                }  
      
                // Data is never null; it's empty if there is no data  
      
                if (exception.Data.Count > 0)  
                {  
                    root.Add  
                    (  
                        new XElement("Data",  
                            from entry in  
                                exception.Data.Cast<DictionaryEntry>()  
                            let key = entry.Key.ToString()  
                            let value = (entry.Value == null) ?  
                                "null" : entry.Value.ToString()  
                            select new XElement(key, value))  
                    );  
                }  
      
                // Add the InnerException if it exists  
      
                if (exception.InnerException != null)  
                {  
                    root.Add  
                    (  
                        new ExceptionXElement  
                            (exception.InnerException, omitStackTrace)  
                    );  
                }  
      
                return root;  
            })())  
        { }  
    }
  

    IWebElement RateQuestionElement = this.Driver.FindElement(By.Id(questionid)); 
    
    IWebElement RateQuestionLabel = RateQuestionElement.FindElement(By.Css("label"));
       
 
    RateQuestionLabel.click();

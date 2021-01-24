	public void RateQuestion(int questionnumber, int rating)
		{
		    string questionid = questionnumber.ToString() + "-" + rating.ToString();
		    IWebElement RateQuestionElement = this.Driver.FindElement(By.XPath("//label[@for='" + questionid + "']"));
		    RateQuestionElement.Click();
		}

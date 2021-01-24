    public void RateQuestion(int questionnumber, int rating)
                {
                    string questionid = questionnumber.ToString() + "-" + rating.ToString();
                    IWebElement RateQuestionElement = this.FindElement(By.Xpath("//*[contains(local-name(), 'label') and contains(@for, questionid)]"));
                    RateQuestionElement.Click();
                }

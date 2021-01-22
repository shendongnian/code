    class Program
    {
        static void Main(string[] args)
        {
            String     xml          = @"<Root>
                                            <AlphaSection></AlphaSection>
                                            <BetaSection>
                                                <Choices>
                                                    <SetA>
                                                        <Choice id='choice1'>Choice One</Choice>
                                                        <Choice id='choice2'>Choice Two</Choice>
                                                    </SetA>
                                                    <SetB>
                                                        <Choice id='choice3'>Choice Three</Choice>
                                                        <Choice id='choice4'>Choice Four</Choice>
                                                    </SetB>
                                                </Choices>
                                            </BetaSection>
                                            <GammaSection></GammaSection>
                                        </Root>";
            XElement    xmlElement  = XElement.Parse(xml);
            var         choiceList  = from c in xmlElement.Descendants().Elements("Choice")
                                      select new {
                                          Name = c.Attribute("id").Value,
                                          Data = c.Value
                                      };
            foreach (var choice in choiceList) {
                Console.WriteLine("Name: {0} Data: {1}", choice.Name, choice.Data );
            }
        }
    }

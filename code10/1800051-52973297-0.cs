public class AssigningEmployee : Employee {
    public string AssigningName { get { return Name; } set { Name = Value; } }
    ...
}
These solutions are all *meh*. The whole point of Insight.Database is to **just work** without a lot of extra work. So...
I opened a github issue to track this: 
https://github.com/jonwagner/Insight.Database/issues/384

private bool IsTypeEqual&lt;TMockedType&gt;(object theFirstObject, object theSecondObject)
{
    Matcher matcher = Is.TypeOf(typeof(TMockedType));
    return matcher.Matches(theFirstObject) && matcher.Matches(theSecondObject);
}

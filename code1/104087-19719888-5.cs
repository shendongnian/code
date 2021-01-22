<input type="submit" name="buttonSave" value="Save"/>
<input type="submit" name="buttonProcess" value="Process"/>
<input type="submit" name="buttonCancel" value="Cancel"/>
And you must specify the names of buttons as arguments in the action like below:
public ActionResult Register(string buttonSave, string buttonProcess, string buttonCancel)
{
    if (buttonSave!= null)
    {
        //save is pressed
    }
    if (buttonProcess!= null)
    {
        //Process is pressed
    }
    if (buttonCancel!= null)
    {
        //Cancel is pressed
    }
}
when user submits the page using one of the buttons, only one of the arguments will have value. I guess this will be helpful for others.
**Update**
This answer is quite old and I actually reconsider my opinion . maybe above solution is good for situation which passing parameter to model's properties. don't bother yourselves and take best solution for your project.

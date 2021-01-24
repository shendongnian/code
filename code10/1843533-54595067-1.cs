public class MiniFormViewModel
{
    public string MyInput { get; set; }
    public bool MyCheck { get; set; }
}
then in your container view model:
public class ContainerViewModel
{ 
    public IEnumerable<MiniFormViewModel> MiniForms { get; set; } 
    //Any other properties you need on the view that will occur a single time 
}
Now, in the JS you'll need to add some manipulation in order to do this:
function getViewModel() {
    //You'll have to decide how you want to get the values of the mini form's fields. Perhaps you might even have a function to supply these values. Up to you.
    return {
        MiniForms: [{
                MyInput: '', //value from the first "mini form' string field
                Mycheck: false //value from the first "mini-form" bool field
            },
            {
                MyInput: '', //value from the second"mini form' string field
                Mycheck: false //value from the second"mini-form" bool field
            }      
        ]
    }
}
Then you'll need to post this back to the server. I'll demonstrate how to do this via the built in JS Fetch function:
        fetch(yourUrlForTheControllerAction,
            {
                method: 'post',
                body: JSON.stringify(getViewModel()),
                headers: {
                    'content-type': 'application/json; charset=UTF-8'
                }
            })
And then blammo, you should be good to go. I excluded the part of dynamically adding the mini form fields because it sounds like you have a solution for that already.

    public class ShowMenu : MonoBehaviour
    {
    
    	public Animator ObjectBtnAnimations;
    
    	public void HideObjControls()
    	{
    		if (ObjectBtnAnimations.GetBool("hide"))
    		{
    			ObjectBtnAnimations.SetBool("hide", false);
    		}
    		else
    		{
    			ObjectBtnAnimations.SetBool("hide", true);
    		}
    	}
    }

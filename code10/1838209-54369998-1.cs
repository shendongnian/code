     <CampaignForm onclose="OnModalClosed" onsubmit="OnSubmit"></CampaignForm>
        @functions{
           public async Task OnSubmit(bool value) {
                    //do some awaiting here 
           }
           public void OnModalClose()=>....; //do something sync ;
        }

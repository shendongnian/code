     <CampaignForm onclose="OnModalClosed" onsubmit="OnSubmit"></CampaignForm>
        @functions{
           public async void OnSubmit(bool value) {
                    //do some awaiting here 
           }
           public void OnModalClose()=>....; //do something sync ;
        }

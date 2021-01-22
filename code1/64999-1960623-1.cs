    public void RegisterUser() {
        try {
            Response.WriteJSONObject(new { Result = "See hello" });
        } 
        catch (Exception err) {
            if (err.Message != "Thread was being aborted.")
                Response.WriteJSONObject(new { Result = err.Message });
            else {
                Response.End();
            }
        }
    }

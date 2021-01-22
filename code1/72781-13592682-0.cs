    catch (Exception ex)
    {
     strMessage = ex.Message.ToString();
    }
    catch (ArgumentNullException aex)
    {
     strMessage = aex.Message;
    }

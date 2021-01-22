    Try
    {
        //error occurs
    }
    catch (AccessDeniedException ex)
    {
        MessageBox.show(ex.Message);
    }
    catch (FieldAccessException)
    {
    }
    // etc...

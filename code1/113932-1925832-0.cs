    private void buttonSend_Click(object sender, EventArgs e){
        try{
        // send text
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textSend.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            //clear textsend textbox
            textSend.Text = "";
    
    
        }
        catch(Exception ex){
    
        // handle error here
        }
        finally {
        // clean up
        }
    }

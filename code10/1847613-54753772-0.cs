    public IHttpActionResult TesteComunicacao(string mensagem)
        {
            MyHub.GetStatus("Message here!");
            return Ok("ok");
        }

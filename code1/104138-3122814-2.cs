    try
            {
                String namePub = servicio.Users.GetInfo().first_name + "ha actualizado su estado";
                String cosa = servicio.Stream.Publish(richTextBox1.Text,
                new attachment()
                {
                    name = namePub,
                    href = "http://www.facebook.com/apps/application.php?id=136818146334647",
                    caption = "Tú tambien puedes usar Escuchando ahora, es facil y rapido",
                    properties = null,
                    media = new List<attachment_media>()
                    {
                        new attachment_media_image()
                        {
                            src="http://www.rammsdio.com.ar/images/img14781001.gif",
                            href = "http://www.facebook.com/apps/application.php?id=136818146334647"
                        }
                    }
                },
                new List<action_link>() 
                {
                    new action_link()
                    {
                        text="Visita SQLeros",
                        href="http://www.sqleros.com.ar/wps"
                    }
                },null,0);
                listBox1.Items.Add("Has actualizado tu estado...");
                richTextBox1.Clear();
                if (checkBox2.Checked)
                    servicio.Stream.AddLike(cosa);
            }
            catch (FacebookException fb)
            {
                listBox1.Items.Add(fb.Message);
            }

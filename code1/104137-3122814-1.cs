    try
            {
                var cancion = "lalalalala";
                String cosa = servicio.Stream.Publish(cancion, null, new List<action_link>()
                {
                  new action_link()
                  {
                    text="Visita SQLeros",
                    href="http://sqleros.com.ar/wps"
                  }
                }, null, 0);
                servicio.Stream.AddLike(cosa); //to add like (Y)
                listBox1.Items.Add(cosa);
            }
            catch (FacebookException fe)
            {
                listBox1.Items.Add(fe.Message);
            }

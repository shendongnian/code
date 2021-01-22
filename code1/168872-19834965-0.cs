    protected void Button1_Click(object sender, EventArgs e)
        {
            this.calcularRota(txtOrigem.Text.Trim(), txtDestino.Text.Trim());
        }
        public void calcularRota(string latitude, string longitude)
        {
            //URL do distancematrix - adicionando endereco de origem e destino
            string url = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", latitude, longitude);
            XElement xml = XElement.Load(url);
            // verifica se o status é ok
            if (xml.Element("status").Value == "OK")
            {
                //Formatar a resposta
                Label3.Text = string.Format("<strong>Origem</strong>: {0}",
                    //Pegar endereço de origem 
                    xml.Element("result").Element("formatted_address").Value);
                //Pegar endereço de destino                    
            }
            else
            {
                Label3.Text = String.Concat("Ocorreu o seguinte erro: ", xml.Element("status").Value);
            }
        }
    }

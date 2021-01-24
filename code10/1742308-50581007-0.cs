        string lista;
        EditText bevasarlolista = null;
        bevasarlolista = view.FindViewById<EditText>(Resource.Id.bevasarlo);
        if (items[position] == "Bevásárlólista")
                    {
                      Button mentes = view.FindViewById<Button>
        (Resource.Id.hozzaad);
                    bevasarlolista.setText(lista);
                mentes.Click += bevasarlolistaMentese;
            }
            private void bevasarlolistaMentese(object sender, EventArgs e)
            {
                lista = bevasarlolista.Text;
                Toast.MakeText(Application.Context, bevasarlolista.Text, ToastLength.Long).Show();
            }

    using (checkinEntities1 db = new checkinEntities1())
{
    var qcheckin = (from c in db.tbpassageiro
                    join g in db.tbviagem on c.idviagem equals g.idviagem
                    where c.idviagem == g.idviagem
                    select new viewModelName()
                    {
                        //get the column values here like
                        Hora = c.Hora,
                        Partida = g.Partida
                    }).ToList();
     gridpass.ItemsSource = qcheckin;

     public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Include(x => x.PessoaFisica).Include(x => x.PessoaFisica.Pessoa).Include(x=> x.PessoaFisica.Pessoa.Endereco).FirstOrDefault(x=>x.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

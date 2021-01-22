    Func<Customer, bool> predicate = c => true;
    if (txtName.Text.Trim() != "")
       predicate = Concatenate(predicate, c => c.Name == txtName.text);
    if (txtEmail.Text.Trim() != "")
       predicate = Concatenate(predicate, c => c.Email == txtEmail.text);
    
    static Func<T, bool> Concatenate(Func<T, bool> a, Func<T, bool> b) {
        return t => a(t) && b(t);
    }

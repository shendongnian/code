        public ActionResult Change(int id)
        {
            CookieHelper.UpdatePeec((PEEC)id);
            return Redirect("/");
        }

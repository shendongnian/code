    [HttpPost]
        public ActionResult BaiTestIQ(int id)
        {
            var cauhoi = from q in data.Questions
                         join a in data.Answers on q.MaTests equals "IQ"
                         where q.MaCHoi == a.MaCHoi && a.keys == id
                         select new baitest()
                         {
                             Cauhoi = q.Noidung,
                             DAn1 = a.DAn1,
                             DAn2 = a.DAn2,
                             DAn3 = a.DAn3,
                             DAn4 = a.DAn4,
                             DAn5 = a.DAn5,
                             DAn6 = a.DAn6,
                         };
            return PartialView(cauhoi);
        }

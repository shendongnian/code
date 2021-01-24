     [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageEverything)]
        public ActionResult DeleteConfirmed(BlogArticle blg, int id)
        {                      
            blg = _context.BlogArticles.Find(id);
            _context.BlogArticles.Remove(blg);
            System.IO.File.Delete(Request.MapPath(blg.ArticleImage));
            _context.SaveChanges();
            return RedirectToAction("Blog", "BlogArticle");
        }
